using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public interface ICarRepository
    {
        Car[] GetByYear(string year);
        Car[] GetByModelOrBrand(string modelPartOrYear);
        Car GetById(int id);
        Car[] GetAllByIds(IEnumerable<int> carIds);
    }
}
