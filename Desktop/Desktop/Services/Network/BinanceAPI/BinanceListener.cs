using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Windows;
using Newtonsoft.Json;

public class BinanceListener<T>
{
    public event EventHandler<T> DataReceived;

    public async Task StartListening(string streamName)
    {
        var _uri = new Uri($"wss://stream.binance.com:9443/ws/{streamName}");
        var _cancellationToken = new CancellationToken();

        using (var client = new ClientWebSocket())
        {
            try
            {
                await client.ConnectAsync(_uri, _cancellationToken);

                var receiveBuffer = new ArraySegment<byte>(new byte[4096]);

                while (client.State == WebSocketState.Open)
                {
                    var result = await client.ReceiveAsync(receiveBuffer, _cancellationToken);
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        T eventData = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(receiveBuffer.Array, 0, result.Count));
                        OnDataReceived(eventData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.ToString());
            }
            finally
            {
                if (client.State == WebSocketState.Open)
                   await client.CloseAsync(WebSocketCloseStatus.NormalClosure, "", _cancellationToken);
            }
        }
    }

    protected virtual void OnDataReceived(T data)
    {
        DataReceived?.Invoke(this, data);
    }
}


