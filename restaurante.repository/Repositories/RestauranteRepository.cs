using System.Collections.Generic;
using System.Linq;
using restaurante.domain;
using restaurante.repository.Data;
using restaurante.repository.Interfaces;

namespace restaurante.repository.Repositories
{
    public class RestauranteRepository : IRestauranteRepository
    {

        DataContext context;

        public RestauranteRepository(DataContext context)
        {
            this.context= context;
        }
        public void Create(Restaurante obj)
        {
            context.Restaurantes.Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Restaurantes.Remove(GetById(id));
        }

        public List<Restaurante> GetAll()
        {
            return context.Restaurantes.ToList();
        }

        public Restaurante GetById(int id)
        {
            return context.Restaurantes.SingleOrDefault(x=>x.id == id);
        }

        public void Update(Restaurante obj)
        {
           var res = GetById(obj.id);
           res.name = obj.name;
           res.endereco = obj.endereco;
           res.bairro = obj.bairro;
           res.cidade = obj.cidade;
           res.estado = obj.estado;
           context.SaveChanges();
        }   
    }
}