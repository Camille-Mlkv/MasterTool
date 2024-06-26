﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolDomain.Entities
{
    public class Notification
    {
        [PrimaryKey, AutoIncrement]
        public int Id {  get; set; }
        public string? Message { get; set; }
        public string? Date { get; set; }
        public int RequestId { get; set; }
        public int ReceiverId { get; set; }
        public bool IsForClient { get; set; }

        public Notification() { }
        public Notification(string message,string date, int requestId,int clientId,bool isForClient) 
        {
            Message = message;
            Date = date;
            RequestId = requestId;
            ReceiverId = clientId;
            IsForClient = isForClient;
        }
    }
}
