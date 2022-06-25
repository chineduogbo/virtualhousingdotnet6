using Virtual_Housing.Models.Dto;
using Virtual_Housing.Models.Model;

namespace Virtual_Housing.Services.Interfaces
{
    public interface IMeetingService
    {
        Task<SuccessDto> CreateMeeting(DateTime? ScheduledAt, string UserId);
        Task<List<Meetings>> ViewMeetings(string UserId);
        Task<Meetings> ViewMeeting(string Id);
        Task<List<Meetings>> ViewMeetingsCreated(string UserId);
        Task<SuccessDto> EditMeeting(Meetings model);
        Task<SuccessDto> DeleteMeeting(string Id);
    }
}
