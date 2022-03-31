using Microsoft.VisualStudio.TestTools.UnitTesting;
using AareonTechnicalTest.Controllers;
using System;
using AareonTechnicalTestTests;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AareonTechnicalTest.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Data.Entity.Infrastructure;

namespace AareonTechnicalTest.Controllers.Tests
{
    [TestClass()]
    public class TicketsControllerTests
    {
        [TestMethod()]
        public void GetTicketsTest()
        {
            var data = new List<Ticket>() { new Ticket { Content = "Test Ticket1", PersonId = 1 },
                new Ticket { Content = "Test Ticket2", PersonId = 2 } }.AsQueryable();

            var mockSet = new Mock<DbSet<Ticket>>();

            mockSet.As<IDbAsyncEnumerable<Ticket>>().Setup(m => m.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<Ticket>(data.GetEnumerator()));
            mockSet.As<IQueryable<Ticket>>().Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<Ticket>(data.Provider));
            mockSet.As<IQueryable<Ticket>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Ticket>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Ticket>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = new Mock<ApplicationContext>();
            mockContext.Setup(m => m.Tickets).Returns(mockSet.Object);

            var service = new TicketsController(mockContext.Object);
            var tickets = service.GetTickets();


            Assert.AreEqual(2, tickets.Result.Value.Count());
        }

        [TestMethod()]
        public async Task GetTicketTest()
        {
            var data = new List<Ticket>() { new Ticket { Id = 1, Content = "Test Ticket1", PersonId = 1 },
                new Ticket {Id = 2, Content = "Test Ticket2", PersonId = 2 } }.AsQueryable();

            var mockSet = new Mock<DbSet<Ticket>>();

            mockSet.As<IDbAsyncEnumerable<Ticket>>().Setup(m => m.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<Ticket>(data.GetEnumerator()));
            mockSet.As<IQueryable<Ticket>>().Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<Ticket>(data.Provider));
            mockSet.As<IQueryable<Ticket>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Ticket>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Ticket>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = new Mock<ApplicationContext>();
            mockContext.Setup(m => m.Tickets).Returns(mockSet.Object);
            var service = new TicketsController(mockContext.Object);
            var ticket = await service.GetTicket(1);
            Assert.AreEqual("Test Ticket1", ticket.Value?.Content);
        }
    }
}