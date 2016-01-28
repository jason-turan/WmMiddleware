using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using Middleware.Jobs;
using Middleware.Jobs.Models;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.Configuration;

namespace Middleware.Alerts
{
    public class AlertJob : IUnitOfWork
    {
        private readonly ILog _log;

        private readonly IJobRepository _jobRepository;

        private readonly IConfigurationManager _configurationManager;

        private const string EmailTemplate = @"<!DOCTYPE html>
                                                <html>
                                                <body>

                                                <h5>Failed Jobs Alert</h5>

                                                <table style='background-color: grey; border-collapse: collapse; font-size: 10px; font-family: Helvetica, Arial, sans-serif;'>
                                                    <tr>
                                                            <th style='border: 1px solid black;'>
                                                                Job Key
                                                            </th>
                                                            <th style='border: 1px solid black;'>
                                                                Last Run Date
                                                            </th>
                                                            <th style='border: 1px solid black;'>
                                                                Last Execution Time
                                                            </th>
                                                            <th style='border: 1px solid black;'>
                                                                Next Run Time
                                                            </th>
                                                   </tr>";

        public AlertJob(ILog log, IJobRepository jobRepository, IConfigurationManager configurationManager )
        {
            _log = log;
            _jobRepository = jobRepository;
            _configurationManager = configurationManager;
        }

        public void RunUnitOfWork(string jobKey)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            while (stopWatch.Elapsed.Minutes < 5)
            {
                _log.Info("Just running...");
                Thread.Sleep(1000);
            }

            ResolveRecoveries();

            var failureList = _jobRepository.GetJobs()
                                            .Where(job => job.LastRunStatus == JobRunStatus.Failure)
                                            .Where(job => job.IsAlerted == false)
                                            .ToList();

            if (failureList.Count > 0)
            {
                var failHtml = BuildFailMessage(failureList);

                SendAlertEmail(failHtml);

                MarkAlerted(failureList);
            }
        }

        private void ResolveRecoveries()
        {
            foreach (var job in _jobRepository.GetJobs()
                                              .Where(job => job.LastRunStatus == JobRunStatus.Success && job.IsAlerted))
            {
                job.IsAlerted = false;
                _jobRepository.UpdateJob(job);
                _log.Info("Removed alerted flag from " + job.JobKey + " because status is no longer failed.");
            }
        }

        private void MarkAlerted(IEnumerable<MiddlewareJob> failureList)
        {
            foreach (var middlewareJob in failureList)
            {
                middlewareJob.IsAlerted = true;
                _jobRepository.UpdateJob(middlewareJob);
            }
        }

        private static string BuildFailMessage(IEnumerable<MiddlewareJob> failureList)
        {
            var failList = new StringBuilder();

            foreach (var middlewareJob in failureList)
            {
                Debug.Assert(middlewareJob.LastRunDateTime != null, "middlewareJob.LastRunDateTime != null");
                failList.Append("<tr>");

                failList.Append("<td style='border: 1px solid black;'>");
                failList.Append(middlewareJob.JobKey);
                failList.Append("</td>");

                failList.Append("<td style='border: 1px solid black;'>");
                failList.Append(middlewareJob.LastRunDateTime.Value.ToString("MMM d yyyy HH:mm:ss"));
                failList.Append("</td>");

                failList.Append("<td style='border: 1px solid black;'>");
                Debug.Assert(middlewareJob.LastRunExecutionTime != null, "middlewareJob.LastRunExecutionTime != null");
                failList.Append(middlewareJob.LastRunExecutionTime.Value + "ms");
                failList.Append("</td>");

                failList.Append("<td style='border: 1px solid black;'>");
                Debug.Assert(middlewareJob.NextRunDateTime != null, "middlewareJob.NextRunDateTime != null");
                failList.Append(middlewareJob.NextRunDateTime.Value.ToString("MMM d yyyy HH:mm:ss"));
                failList.Append("</td>");

                failList.Append("</tr>");
            }

            failList.Append("</table></body></html>");

            return EmailTemplate + failList;
        }

        private void SendAlertEmail(string failList)
        {
            var distributionList = 
                _configurationManager.GetKey<string>(ConfigurationKey.AlertDistributionList);
            var smptServer = 
                _configurationManager.GetKey<string>(ConfigurationKey.SmptServer);
            var message = 
                new MailMessage("noreply@newbalance.com", 
                                distributionList, 
                                "WmMiddleware Failure", 
                                failList)
                {
                    Priority = MailPriority.High, IsBodyHtml = true
                };

            using (var client = new SmtpClient(smptServer))
            {
                client.Send(message);
            }
        }
    }
}
