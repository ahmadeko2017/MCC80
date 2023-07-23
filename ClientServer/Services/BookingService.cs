using ClientServer.Contracts;
using ClientServer.DTOs.Bookings;
using ClientServer.Models;

namespace ClientServer.Services;

public class BookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public IEnumerable<BookingDto> GetAll()
    {
        var bookings = _bookingRepository.GetAll();
        if (!bookings.Any())
        {
            return Enumerable.Empty<BookingDto>();
        }

        var bookingDtos = new List<BookingDto>();
        foreach (var booking in bookings)
        {
            bookingDtos.Add((BookingDto)booking);
        }

        return bookingDtos;
    }

    public BookingDto? GetByGuid(Guid guid)
    {
        var booking = _bookingRepository.GetByGuid(guid);
        if (booking is null)
        {
            return null;
        }

        return (BookingDto)booking;
    }

    public NewBookingDto? Create(NewBookingDto newBookingDto)
    {
        var booking = _bookingRepository.Create(newBookingDto);
        if (booking is null)
        {
            return null;
        }

        return (NewBookingDto)booking;
    }

    public int Update(BookingDto bookingDto)
    {
        var booking = _bookingRepository.GetByGuid(bookingDto.Guid);
        if (booking is null)
        {
            return -1;
        }

        Booking toUpdate = bookingDto;
        toUpdate.CreatedDate = booking.CreatedDate;
        var result = _bookingRepository.Update(toUpdate);

        return result ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var booking = _bookingRepository.GetByGuid(guid);
        if (booking is null)
        {
            return -1;
        }

        var result = _bookingRepository.Delete(booking);
        return result ? 1 : 0;
    }
}