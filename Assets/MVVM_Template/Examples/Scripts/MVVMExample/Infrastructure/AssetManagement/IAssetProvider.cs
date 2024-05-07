using System.Threading.Tasks;
using UnityEngine;

namespace MVVMExample.Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        Task<T> Load<T>(string key) where T : Object;
    }
}