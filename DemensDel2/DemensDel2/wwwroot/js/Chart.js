function convertToArray(obj) {
    return Object.keys(obj).map(function (key) {
        return obj[key];
    });
}

var canvas = document.getElementById("chart");
var ctx = canvas.getContext('2d');

var Exercises = canvas.getAttribute("data-Exercise");
var ExerciseData = canvas.getAttribute("data-ExerciseData");

var d = ExerciseData.split(",");
var r = Exercises.split(",");

var myChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: r,
        datasets: [{
            label: 'Udførelse proocent',
            data: d,
            backgroundColor: [
                'rgba(230,39,57, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)'
            ],
            borderColor: [
                'rgba(161,27,39,1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)'
            ],
            borderWidth: 4,
            pointBorderColor: "#fff",
            pointBackgroundColor: "rgba(161, 27, 39, 1)",
            pointBorderWidth: 2,
            pointHoverRadius: 10,
            pointHoverBackgroundColor: "#EBAC31",
            pointHoverBorderColor: "rgba(220,220,220,1)",
            pointHoverBorderWidth: 2,
            pointRadius: 10,
            pointHitRadius: 10,

        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    min: 0,
                    max: 100,
                    stepSize: 10,
                    beginAtZero: true
                }
            }]
        }
    }
});