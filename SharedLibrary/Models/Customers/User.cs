﻿using Microsoft.EntityFrameworkCore;

// Внимание! Добавить синхронизацию с аккаунтом с номером и без!

namespace SharedLibrary.Models.Customers
{
    public class User
    {
        public User() { }

        public Guid UserId { get; set; } = Guid.NewGuid();

        public string? Name { get; set; } = null;

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public List<Adress>? Adresses { get; set; } = new List<Adress>();

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public List<Order>? Orders { get; set; } = new List<Order>();

        public string? Phone { get; set; } = string.Empty;

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public required Cart Cart { get; set; }
    }
}
