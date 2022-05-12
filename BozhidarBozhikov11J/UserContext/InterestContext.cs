using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserContext
{
    public class InterestContext : IDB<Interest, int>
    {
        private IzpitDBContext _context;

        public InterestContext(IzpitDBContext context)
        {
            context = _context;
        }

        public void Create(Interest item)
        {
            try
            {
                _context.Interests.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Interest Read(int key)
        {
            try
            {
                Interest interestFromDB = _context.Interests.SingleOrDefault(id => id.ID == key);

                if (interestFromDB == null)
                {
                    throw new ArgumentException("There is no interest with that key!");
                }

                return interestFromDB;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Interest> ReadAll()
        {
            try
            {
                return _context.Interests.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Interest item)
        {
            try
            {
                Interest interestFromDB = Read(item.ID);

                _context.Entry(interestFromDB).CurrentValues.SetValues(item);

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
                _context.Interests.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
