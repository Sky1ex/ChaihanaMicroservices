﻿using AspireForChaihana.ServiceDefaults.Models.Customers;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataBase;
using WebApplication1.DataBase_and_more;
using WebApplication1.Repository.Default;

namespace WebApplication1.Repository
{
    public class UserRepository : Repository<User, WebDbForCustomers>, IDisposable
    {
        private bool disposed = false;

        public UserRepository(WebDbForCustomers context) : base(context) { }

        public async Task<User?> GetByPhone(string phoneNumber)
        {
            return await _context.Users
                .Include(u => u.Adresses)
                .FirstOrDefaultAsync(u => u.Phone == phoneNumber);
        }

        public async Task<User?> GetByIdWithAddresses(Guid userId)
        {
            return await _context.Users
                .Include(u => u.Adresses)
                .FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<User?> GetByIdWithOrders(Guid userId)
        {
            return await _context.Users
                .Include(u => u.Orders)
                .FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<User?> GetByIdFull(Guid userId)
        {
			/*return await _context.Users
                .Include(u => u.Orders)
                .Include(u => u.Adresses)
                .FirstOrDefaultAsync(u => u.UserId == userId);*/
			/*return await _context.Users
                .Include(c => c.Orders)
                .ThenInclude(ce => ce.OrderElement)
                .ThenInclude(ced => ced.ProductId)
                .Include(c => c.Orders)
                *//*.ThenInclude(ce => ce.Adress)*//*
                .FirstOrDefaultAsync(c => c.UserId == userId);*/

			return await _context.Users
				.Include(c => c.Orders)
                .ThenInclude(c => c.Adress)
				.Include(c => c.Orders)
				.ThenInclude(ce => ce.OrderElement)
				/*.ThenInclude(ced => ced.ProductId)*/
				.FirstOrDefaultAsync(c => c.UserId == userId);
		}

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
