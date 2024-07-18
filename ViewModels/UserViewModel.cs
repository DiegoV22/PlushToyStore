using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlushToyStore.Models;
using PlushToyStore.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PlushToyStore.ViewModels
{
    public partial class UserViewModel : ObservableObject
    {
        private readonly UserService _userService;

        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();

        [ObservableProperty]
        private User _selectedUser;

        public UserViewModel()
        {
            // Constructor sin parámetros requerido por el error
        }

        public UserViewModel(UserService userService)
        {
            _userService = userService;
            LoadUsers();
        }

        public async void LoadUsers()
        {
            var users = await _userService.GetUsersAsync();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        [RelayCommand]
        public async Task AddUser(User user)
        {
            if (user != null)
            {
                var result = await _userService.AddUserAsync(user);
                if (result > 0)
                {
                    Users.Add(user);
                }
                else
                {
                    Console.WriteLine("Failed to add user.");
                }
            }
        }

        [RelayCommand]
        public async Task UpdateUser(User user)
        {
            if (user != null)
            {
                var result = await _userService.UpdateUserAsync(user);
                if (result > 0)
                {
                    var index = Users.IndexOf(user);
                    if (index != -1)
                    {
                        Users[index] = user;
                    }
                }
                else
                {
                    Console.WriteLine("Failed to update user.");
                }
            }
        }

        [RelayCommand]
        public async Task DeleteUser(User user)
        {
            if (user != null)
            {
                var result = await _userService.DeleteUserAsync(user);
                if (result > 0)
                {
                    Users.Remove(user);
                }
                else
                {
                    Console.WriteLine("Failed to delete user.");
                }
            }
        }
    }
}
