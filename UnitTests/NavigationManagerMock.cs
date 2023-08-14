using Microsoft.AspNetCore.Components;
using Moq;

namespace UnitTests
{
    public static class NavigationManagerMock
    {
        public static NavigationManager Create()
        {
            return new Mock<NavigationManager>().Object;
        }
    }
}