using System.Collections.Generic;
using System.Linq;
using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Wm.DataFiles;
using WmMiddleware.Configuration;
using WmMiddleware.Configuration.Manhattan;
using WmMiddleware.ProductUpdating.Models;
using WmMiddleware.TransferControl.Control;

namespace WmMiddleware.ProductUpdating.Repositories
{
    public class ManhattanProductRepository : IProductWriter
    {
        private readonly IManhattanConfiguration _configuration;
        private readonly DataFileRepository<ManhattanProduct> _productRepository = new DataFileRepository<ManhattanProduct>();
        private readonly ITransferControlManager _transferControlManager;
        private readonly IJobRepository _jobRepository;

        public ManhattanProductRepository(IManhattanConfiguration configuration, 
                                          ITransferControlManager transferControlManager,
                                          IJobRepository jobRepository)
        {
            _configuration = configuration;
            _transferControlManager = transferControlManager;
            _jobRepository = jobRepository;
        }

        public void SaveProducts(IEnumerable<Product> products)
        {
            var allProducts = products.ToList();
            if (!allProducts.Any())
            {
                return;
            }

            var warehouseNumber = _configuration.GetKey<string>(ConfigurationKey.WarehouseNumber);
            var companyNumber = _configuration.GetKey<string>(ConfigurationKey.CompanyNumber);

            var controlNumber = _configuration.GetBatchControlNumber();
            var batchControlNumber = warehouseNumber + controlNumber.ToString("D8");

            var productList = allProducts.Select(product => new ManhattanProduct(product, batchControlNumber, companyNumber, warehouseNumber)).ToList();

            var productPath = _configuration.GetPath(ManhattanDataFileType.ProductUpdatingProductPath, controlNumber);
            _productRepository.Save(productList, productPath);

            _transferControlManager.SaveTransferControl(batchControlNumber, 
                                                        new List<string> { productPath }, 
                                                        _jobRepository.GetJob(JobKey.ProductUpdating).JobId);
        }
    }
}
