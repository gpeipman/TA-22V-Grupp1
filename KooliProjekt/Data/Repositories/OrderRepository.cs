using KooliProjekt;
using Microsoft.EntityFrameworkCore;
namespace KooliProjekt.Data.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
       
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public override async Task<PagedResult<Order>> List(int page, int pageSize)
        {
            var result = await Context.Orders
                .Include(o => o.Product)
                .Include(o => o.Customer)
                .GetPagedAsync(page, pageSize);
            return result;

        }
        public async Task<List<Order>> GetAllOrders()
        {
            return await Context.Orders.ToListAsync();
        }
        public async Task<List<Order>> GetCustomerOrders(string email)
        {
            var result = await Context.Orders
                .Where(o => o.Customer.Email == email)
                .Include(o => o.Customer)
                .Include(o => o.Product)
                .ToListAsync();
            return result;
        }
        

        public override async Task<Order> GetById(int id)
        {
            var order = await Context.Orders
                .Include(o => o.Product)
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            return order;
        }

        public override async Task Save(Order order)
        {
            await base.Save(order);
        }

        public async Task Delete(int? id)
        {
            var order = await Context.Orders.FindAsync(id);

            if(order != null)
            {
                Context.Orders.Remove(order);
            }
            await Context.SaveChangesAsync();
        }
        // Queriyes

        public bool Existance(int Id)
        {
            return Context.Orders.Any(e => e.Id == Id);
        }

        public async Task Entry(Order order)
        {
            Context.Entry(order).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task Add(Order order)
        {
            Context.Orders.Add(order);
            await Context.SaveChangesAsync();
        }

        
    }
}