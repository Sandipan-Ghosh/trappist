﻿namespace Promact.Trappist.DomainModel.ApplicationClasses.BasicSetup
{
    public class EmailSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConnectionSecurityOption { get; set; }
    }
}
