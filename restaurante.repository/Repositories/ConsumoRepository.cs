using System.Collections.Generic;
using System.Linq;
using restaurante.domain;
using restaurante.repository.Data;
using restaurante.repository.Interfaces;

namespace restaurante.repository.Repositories
{
    public class ConsumoRepository : IConsumoRepository
    {
         DataContext context;
        public void Create(Consumo obj)
        {
            context.Consumos.Add(obj);
            context.SaveChanges();        }

        public void Delete(int id)
        {
            context.Consumos.Remove(GetById(id));
        }

        public List<Consumo> GetAll()
        {
           return context.Consumos.ToList();
        }

        public Consumo GetById(int id)
        {
            return context.Consumos.SingleOrDefault(x=>x.id == id);
        }

        public void Update(Consumo obj)
        {
            var con = GetById(obj.id);
            con.restaurante = obj.restaurante;
            con.valor = obj.valor;
            con.data = obj.data;
            context.SaveChanges();
        }
    }
}