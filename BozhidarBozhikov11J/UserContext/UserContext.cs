using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserContext
{
    public class UserContext : IDB<User, int>
    {
        private IzpitDBContext _context;

        public UserContext(IzpitDBContext context)
        {
            context = _context;
        }

        public void Create(User item)
        {
            try
            {
                _context.Users.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User Read(int key)
        {
            try
            {
                User userFromDB = _context.Users.SingleOrDefault(id => id.ID == key);

                if (userFromDB == null)
                {
                    throw new ArgumentException("There is no user with that key!");
                }

                return userFromDB;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<User> ReadAll()
        {
            try
            {
                return _context.Users.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(User item)
        {
            try
            {
                User userFromDB = Read(item.ID);

                _context.Entry(userFromDB).CurrentValues.SetValues(item);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int key)
        {
            try
            {
                _context.Users.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
