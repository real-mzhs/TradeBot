using System.Net.WebSockets;
using System.Text;
using System.Windows;
using Newtonsoft.Json;

namespace Desktop.Services.Network.BinanceAPI;

public class BinanceListener<T>
{
    public event EventHandler<T>? DataReceived;

    public async Task StartListening(string streamName)
    {
        var uri = new Uri($"wss://stream.binance.com:9443/ws/{streamName}");
        var cancellationToken = new CancellationToken();

        using var client = new ClientWebSocket();
        try
        {
            await client.ConnectAsync(uri, cancellationToken);

            var receiveBuffer = new ArraySegment<byte>(new byte[4096]);

            while (client.State == WebSocketState.Open)
            {
                var result = await client.ReceiveAsync(receiveBuffer, cancellationToken);
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var eventData = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(receiveBuffer.Array, 0, result.Count));
                    OnDataReceived(eventData);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Exception: " + ex.Message);
        }
        finally
        {
            if (client.State == WebSocketState.Open)
                await client.CloseAsync(WebSocketCloseStatus.NormalClosure, "", cancellationToken);
        }
    }

    private void OnDataReceived(T data)
    {
        DataReceived?.Invoke(this, data);
    }
}