﻿using System;
using Hangfire.Common;
using Hangfire.Server;
using Hangfire.Storage;
using Moq;

namespace Hangfire.Core.Tests
{
    class PerformContextMock
    {
        private readonly Lazy<PerformContext> _context;

        public PerformContextMock()
        {
            Connection = new Mock<IStorageConnection>();
            BackgroundJob = new BackgroundJobMock();
            CancellationToken = new Mock<IJobCancellationToken>();

            _context = new Lazy<PerformContext>(
                () => new PerformContext(Connection.Object, BackgroundJob.Object, CancellationToken.Object));
        }
        
        public Mock<IStorageConnection> Connection { get; set; }
        public BackgroundJobMock BackgroundJob { get; set; }
        public Mock<IJobCancellationToken> CancellationToken { get; set; } 

        public PerformContext Object
        {
            get { return _context.Value; }
        }

        public static void SomeMethod()
        {
        }
    }
}
