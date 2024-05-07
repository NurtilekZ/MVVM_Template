using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MVVMExample.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, Object> _cachedAssets = new();

        public async Task<T> Load<T>(string key) where T : Object
        {
            if (_cachedAssets.TryGetValue(key, out var cachedAsset)) 
                return cachedAsset as T;
            
            var asset = await Resources.LoadAsync<T>(key);
            if (asset == null) Debug.Log($"[AssetProvider] Asset '{key}' Not Found");

            _cachedAssets[key] = asset;
            return asset as T;
        }

        private void CleanUp()
        {
            if (_cachedAssets.Count == 0)
                return;
            
            foreach (var asset in _cachedAssets.Values) 
                Resources.UnloadAsset(asset);
            
            _cachedAssets.Clear();
        }

        public void Dispose()
        {
            CleanUp();
        }
    }
}