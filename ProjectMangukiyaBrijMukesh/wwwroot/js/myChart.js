function VwByMediaType() {
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Media Type');
    data.addColumn('number', 'Count');
    var x = document.getElementById("myData").innerText;
    document.getElementById("myData").innerHTML = "Comparison of number of movies and tv shows";
    x = x.substring(1);
    x = '[' + x + ']';
    x = JSON.parse(x);
    data.addRows(x);
    var options_pie = {
        title: 'Number of Movies vs Tv shows in WatchLists',
        width: 700, height: 350,
    };
    var chart = new google.visualization.PieChart(document.getElementById('myPieChart'));
    chart.draw(data, options_pie);
}

function VwGenreCount() {
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Genre');
    data.addColumn('number', 'Count');
    var x = document.getElementById("myData").innerText;
    document.getElementById("myData").innerHTML = "What genres you prefer:";
    x = x.substring(1);
    x = '[' + x + ']';
    x = JSON.parse(x);
    data.addRows(x);
    var options_pie = {
        title: 'No.of movies or tv shows per genre',
        width: 700, height: 400,
        is3D: true,
    };
    var chart = new google.visualization.PieChart(document.getElementById('myPieChart'));
    chart.draw(data, options_pie);
    var options_bar = {
        title: 'No.of movies or tv shows per genre',
        hAxis: { title: 'Number', minValue: 0 },
        vAxis: { title: 'Genre' },
        height: 500, width: 700,
    };
    chart = new google.visualization.BarChart(document.getElementById('barChart'));
    chart.draw(data, options_bar);
}

function VwCountByDate() {
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Date');
    data.addColumn('number', 'Content Added');
    var x = document.getElementById("myData").innerText;
    document.getElementById("myData").innerHTML = "When you added media";
    x = JSON.parse(x);
    x.forEach(function (row) {
        data.addRow([row.AddedDate, row.CountDate]);
    });
    var options_line = {
        aggregationTarget: 'category',
        title: 'When you added media',
        width: 950, height: 400,
        curveType: 'function',
        hAxis: {
            title: 'Date'
        },
        vAxis: {
            title: 'Activity'
        }
    };
    var chart = new google.visualization.LineChart(document.getElementById('LineChart'));
    chart.draw(data, options_line);
    var options_bar = {
        hAxis: { title: 'Number', minValue: 0 },
        vAxis: { title: 'Date' },
        height: 500, width: 700,
    };
    chart = new google.visualization.BarChart(document.getElementById('barChart'));
    chart.draw(data, options_bar);
}