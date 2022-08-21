﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bot_Biblioteca_Selenium.Interfaces
{
    public interface IEncoder
    {
        string Encrypt(string password);
        string Decrypt(string encodedPassword);
    }
}
