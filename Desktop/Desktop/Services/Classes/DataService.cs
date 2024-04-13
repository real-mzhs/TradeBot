using Desktop.Messages;
using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Classes;

public class DataService : IDataService
{
    private readonly IMessenger _messenger;

    public DataService(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void SendData<T>(T data) where T : IData
    {
        _messenger.Send(new UserDataMessage()
        {
            Data = data
        });
    }
}
