using AutoMapper;
using BookstoreAPI.Application.Model;
using BookstoreAPI.Controllers.Requests.BookRequests;
using BookstoreAPI.Domain.Entities;
using BookstoreAPI.Infrastructure.Repository.Interfaces;
using System.Collections;

namespace BookstoreAPI.Application.Service
{
    public interface IBookService
    {
        Task<BookDTO> GetBookByIdAsync(int id);
        Task<IEnumerable<BookDTO>> GetAllBooksAsync();
        Task AddBookAsync(CreateBookRequest book);
        Task UpdateBookAsync(UpdateBookRequest book);
        Task<bool> DeleteBookAsync(UpdateBookRequest book);
    }

    public class BookService: IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }
            return _mapper.Map<BookDTO>(book);
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return _mapper.Map<IEnumerable<BookDTO>>(books);
        }

        public async Task AddBookAsync(CreateBookRequest book)
        {
            await _bookRepository.AddBookAsync(_mapper.Map<Book>(book));
            await _bookRepository.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(UpdateBookRequest book)
        {
            await _bookRepository.UpdateBookAsync(_mapper.Map<Book>(book));
            await _bookRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteBookAsync(UpdateBookRequest book)
        {
            var deleted = await _bookRepository.DeleteBookAsync(_mapper.Map<Book>(book));
            if (!deleted)
            {
                return false;
            }
            await _bookRepository.SaveChangesAsync();
            return true;
        }
    }
}
