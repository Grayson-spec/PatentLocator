/*
*
* UserService
*
* This encapsulates business logic for managing the user, which provides abstraction
* between the controller and repository.
*
* This service uses the IUserRepository to interact with the data, allowing 
* for decoupling and testability.
*/
using backend.Models;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;
using backend.Infrastructure; 

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<IPagination<User>> GetUsersAsync(int pageIndex = 0, int pageSize = 10)
        {
            try
            {
                return await _userRepository.GetUsersAsync(pageIndex, pageSize);
            }
            catch (DatabaseException ex)
            {
                _logger.LogError(ex, "Error occurred in the service layer while fetching users.");
                throw new ServiceException("There was an issue fetching the users. Please try again later.");
            }
        }

        public async Task<User?> GetUserAsync(int id)
        {
            try
            {
                return await _userRepository.GetUserAsync(id);
            }
            catch (DatabaseException ex)
            {
                _logger.LogError(ex, "Error occurred in the service layer while fetching a user.");
                throw new ServiceException("There was an issue fetching the user. Please try again later.");
            }
        }

        public async Task CreateUserAsync(User user)
        {
            try
            {
                await _userRepository.CreateUserAsync(user);
            }
            catch (DatabaseException ex)
            {
                _logger.LogError(ex, "Error occurred in the service layer while creating a user.");
                throw new ServiceException("There was an issue creating the user. Please try again later.");
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            try
            {
                await _userRepository.UpdateUserAsync(user);
            }
            catch (DatabaseException ex)
            {
                _logger.LogError(ex, "Error occurred in the service layer while updating a user.");
                throw new ServiceException("There was an issue updating the user. Please try again later.");
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            try
            {
                await _userRepository.DeleteUserAsync(id);
            }
            catch (DatabaseException ex)
            {
                _logger.LogError(ex, "Error occurred in the service layer while deleting a user.");
                throw new ServiceException("There was an issue deleting the user. Please try again later.");
            }
        }
    }
}
