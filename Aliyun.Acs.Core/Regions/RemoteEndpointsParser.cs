using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliyun.Acs.Core.Auth;
using Aliyun.Acs.Core.Regions.Location;
using Aliyun.Acs.Core.Regions.Location.Model;

namespace Aliyun.Acs.Core.Regions
{
    class RemoteEndpointsParser
    {
        private DescribeEndpointService describeEndpointService;

        public void SetDescribeEndpointService(DescribeEndpointService describeEndpointService)
        {
            this.describeEndpointService = describeEndpointService;
        }

        public static RemoteEndpointsParser InitRemoteEndpointsParser()
        {
            RemoteEndpointsParser parser = new RemoteEndpointsParser();
            parser.SetDescribeEndpointService(new DescribeEndpointService());
            return parser;
        }

        public Endpoint GetEndpoint(String regionId, String product, String locationProduct,
                                    Credential credential, LocationConfig locationConfig)
        {
            if (null == locationProduct)
            {
                return null;
            }
            Endpoint endpoint = null;

            DescribeEndpointResponse response = describeEndpointService.DescribeEndpoint(regionId, locationProduct,
                    credential, locationConfig);
            if (null == response)
            {
                return endpoint;
            }

            ISet<string> regionIds = new HashSet<String>();
            regionIds.Add(regionId);

            List<ProductDomain> productDomainList = new List<ProductDomain>();
            productDomainList.Add(new ProductDomain(product, response.Endpoint));
            endpoint = new Endpoint(response.RegionId, regionIds, productDomainList);
            return endpoint;
        }

        public async Task<Endpoint> GetEndpointAsync(String regionId, String product, String locationProduct,
                                    Credential credential, LocationConfig locationConfig)
        {
            if (null == locationProduct)
            {
                return null;
            }
            
            var response = await describeEndpointService.DescribeEndpointAsync(regionId, locationProduct,
                    credential, locationConfig);
            if (null == response)
            {
                return null;
            }

            var regionIds = new HashSet<String>
            {
                regionId
            };

            var productDomainList = new List<ProductDomain>
            {
                new ProductDomain(product, response.Endpoint)
            };
            var endpoint = new Endpoint(response.RegionId, regionIds, productDomainList);
            return endpoint;
        }
    }
}
