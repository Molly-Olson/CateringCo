namespace CateringCo.Services
{
    public class CateringRequestService
    {
        private readonly CateringCoContext _context;
        public CateringRequestService(CateringCoContext context)
        {
            _context = context;
        }
        public async Task<List<CateringRequestModel>> GetAllAsync()
        {
            return await _context.CateringRequests
                .Where(r => !string.IsNullOrEmpty(r.LastName))
                .ToListAsync();
        }
    }
}
