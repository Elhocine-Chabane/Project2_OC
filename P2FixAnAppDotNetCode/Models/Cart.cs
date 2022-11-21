using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Read-only property for dispaly only
        /// </summary>
        /// 
        private List<CartLine> _Lines = new List<CartLine>();
      
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            return _Lines;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        ///  // TODO implement the method
        public void AddItem(Product product, int quantity)
        {
            if(_Lines.Exists(x => x.Product.Id == product.Id))
            {
                foreach(CartLine line in _Lines)
                {
                    if(line.Product.Id == product.Id)
                    {
                        line.Quantity += quantity;
                    }
                }
            }
            else
            {
                _Lines.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity,
                    OrderLineId = _Lines.Count() + 1
                }) ;
            }

           
            
            
        
            
           
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            double sum =0.0;
            
            // TODO implement the method
            foreach(CartLine line in _Lines)
            {
                sum += (line.Quantity * line.Product.Price);

            }
          
            
            return sum;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO implement the method
            double average = 0.0;
            double totalQuantity = 0.0;
            foreach(var line in _Lines)
            {
                average += (line.Quantity * line.Product.Price);
                totalQuantity += line.Quantity; 
            }
            return average/totalQuantity;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            Product foundProduct = null;
            // TODO implement the method
            foreach(var line in _Lines)
            {
                if (line.Product.Id == productId)
                    foundProduct = line.Product;
                    
            }
            return foundProduct;
        }

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
