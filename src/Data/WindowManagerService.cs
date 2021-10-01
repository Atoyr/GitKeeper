using System;
using System.IO;
using GitKeeper;

namespace GitKeeper.Data
{
    public class WindowManagerService
    {
        private bool isLoading = false;
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                OnIsLoadingChanged?.Invoke();
            }
        }

        public event Action OnIsLoadingChanged;

        public WindowManagerService(){}
    }
}

