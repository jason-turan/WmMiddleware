function JobViewModel() {
    var self = this;

    self.jobCollection = ko.observableArray();

    self.lastUpdated = ko.observable();

    window.setInterval(function() {
            self.updateJobTable();
        }, 5000
    );

    self.toggleActive = function(job) {
        var currentStatus;

        if (job.IsActive) {
            currentStatus = 'deactivate';
        } else {
            currentStatus = 'activate';
        }

        if (confirm("Are you sure you want to " + currentStatus + " " + job.JobKey + "?")) {
            job.IsActive = !job.IsActive;
            self.saveJobActiveStatus(job);
        }
    };

    self.executeJob = function(job) {
        if (confirm("Are you sure you want to launch " + job.JobKey + "?")) {

            if (!job.IsActive) {
                alert("You are launching an inactive job. This will activate the job.");
            }

            self.launchJob(job);
        }
    };

    self.changeSchedule = function(job) {

        var newSchedule = prompt("Enter the new schedule for " + job.JobKey, job.Schedule);

        if (newSchedule != null) {
            job.Schedule = newSchedule;
            self.saveJobSchedule(job);
        }

        self.isTableVisible(true);
    };

    $(document).ready(function() {
        self.updateJobTable();
    });


    self.saveJobSchedule = function (job) {
        $.ajax({
            type: 'POST',
            url: myApp.Urls.baseUrl+'Jobs/SaveJobSchedule',
            data: ko.toJSON(job),
            contentType: 'application/json',
            success: function (data) {
                self.updateJobTable();
            },
            error: function (data) {
                alert('Failed to schedule job (scheduler service needs to be restarted for job to reflect any new schedules)');
            }
        });
    };

    self.saveJobActiveStatus = function(job) {
        $.ajax({
            type: 'POST',
            url: myApp.Urls.baseUrl + 'Jobs/SaveJobActiveStatus',
            data: ko.toJSON(job),
            contentType: 'application/json',
            success: function(data) {
                self.updateJobTable();
            },
            error: function(data) {
                   alert('Failed to launch job');
            }
        });
    };

    self.launchJob = function (job) {
        $.ajax({
            type: 'POST',
            url: myApp.Urls.baseUrl + 'Jobs/LaunchJob',
            data: ko.toJSON(job),
            contentType: 'application/json',
            success: function (data) {
                self.updateJobTable();
            },
            error: function(xhr, status, error) {
                var err = eval("(" + xhr.responseText + ")");
                alert('Failed to launch job: ' + err);
            }
        });
    };

    self.updateJobTable = function() {

        $.ajax({
            type: 'GET',
            url: myApp.Urls.baseUrl + 'Jobs/GetIndex'
        }).done(function(data) {
            self.jobCollection(data);
            self.notifyUpdate();
        }).error(function(ex) {
            console.log('failed to load jobs!!' + ex);
        });
    };

    self.notifyUpdate = function ()
    {
        self.lastUpdated(new Date());
    };
};

ko.applyBindings(new JobViewModel());