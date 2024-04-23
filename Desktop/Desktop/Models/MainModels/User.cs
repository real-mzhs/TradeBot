﻿using Desktop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models.MainModels;

public class User
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }    

    public User() { }

    public User(string email, string password)
    {
        Id = Guid.NewGuid().ToString();       
        Email = email;
        Password = password;
    }
}
