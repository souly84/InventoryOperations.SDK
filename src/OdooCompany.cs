﻿using System;
using System.Threading.Tasks;
using PortaCapena.OdooJsonRpcClient;
using PortaCapena.OdooJsonRpcClient.Models;
using Warehouse.Core;

namespace Odoo.Warehouse.SDK
{
    public class OdooCompany : ICompany
    {
        private OdooClient _client;

        public OdooCompany(
            string companyUri,
            string dbName
        ) : this(
                new OdooConfig(
                    companyUri,
                    dbName,
                    string.Empty,
                    string.Empty
                )
            )
        {
        }

        public OdooCompany(OdooConfig config)
            : this(new OdooClient(config)
            )
        {
        }

        public OdooCompany(OdooClient client)
        {
            _client = client;
        }

        public ICustomers Customers => throw new NotImplementedException();

        public IUsers Users => throw new NotImplementedException();

        public IWarehouse Warehouse => new OdooWarehouse(_client);

        public async Task<IUser> LoginAsync(string userName, string password)
        {
            _client = new OdooClient(
                new OdooConfig(
                    _client.Config.ApiUrl,
                    _client.Config.DbName,
                    userName,
                    password
                )
            );

            var result = await _client.LoginAsync();
            if (result.Failed)
            {
                throw new OdooInvalidLoginException<int>(
                    "Login failed: Login/Password can be wrong",
                    result
                );
            }

            return new OdooUser(_client);
        }
    }
}
