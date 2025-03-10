﻿using System.Net.Http.Json;

namespace BlazingPizza.Client;

public class OrdersClient
{
    private readonly HttpClient httpClient;

    public OrdersClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<OrderWithStatus>> GetOrders()
    {
        return await httpClient.GetFromJsonAsync("orders", OrderContext.Default.ListOrderWithStatus) ?? new();
    }

    public async Task<OrderWithStatus> GetOrder(int orderId)
    {
        return await httpClient.GetFromJsonAsync($"orders/{orderId}", OrderContext.Default.OrderWithStatus) ?? new();
    }

    public async Task<int> PlaceOrder(Order order)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync("orders", order, OrderContext.Default.Order);
            response.EnsureSuccessStatusCode();
            var orderId = await response.Content.ReadFromJsonAsync<int>();
            return orderId;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al enviar pedido: {ex.Message}");
            throw;
        }
    }

    public async Task SubscribeToNotifications(NotificationSubscription subscription)
    {
        var response = await httpClient.PutAsJsonAsync("notifications/subscribe", subscription);
        response.EnsureSuccessStatusCode();
    }
}
