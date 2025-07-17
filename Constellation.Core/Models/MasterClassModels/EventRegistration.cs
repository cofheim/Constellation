using Constellation.Core.Enums.Payments;
using Constellation.Core.Enums.Registration;
using Constellation.Core.Models.UserModels;

namespace Constellation.Core.Models.MasterClassModels
{
    public class EventRegistration
    {
        public Guid Id { get; }
        public User User { get; }
        public RegistrationStatus Status { get; private set; }
        public PaymentStatus PaymentStatus { get; private set; }
        public PaymentMethod? PaymentMethod { get; private set; }
        public decimal PaidAmount { get; private set; }
        public DateTime RegisteredAt { get; }
        public DateTime? CancelledAt { get; private set; }
        public string? CancellationReason { get; private set; }
    }
}
