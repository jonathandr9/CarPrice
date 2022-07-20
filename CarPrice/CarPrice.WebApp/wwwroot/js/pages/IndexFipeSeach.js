
$(document).ready(function () {

});

function consultaPrecosFipe() {
    var base_url = window.location.origin;

    $("#alertSearch").attr("hidden", true);

    var url = base_url + "/Search/SearchByFipeCode"

    $.get(url, function (data) {

        if (type = "sucess") {

        } else {
            $("#alertSearchMessage").text(data.message);
            $("#alertSearch").attr("hidden", false);
        }
        //fillInPriceChart(data);
        //alert("Load was performed.");
    });

    fillInPriceChart();    
}

function fillInPriceChart() {

    const series = {
        "monthDataSeries1": {
            "prices": [
                8107.85,
                8128.0,
                8122.9,
                8165.5,
                8340.7
            ],
            "dates": [
                "Jan 2022",
                "Fev 2022",
                "Mar 2022",
                "Abr 2022",
                "Jun 2022"
            ]
        }
    }

    new ApexCharts(document.querySelector("#areaChart"), {
        series: [{
            name: "STOCK ABC",
            data: series.monthDataSeries1.prices
        }],
        chart: {
            type: 'area',
            height: 350,
            zoom: {
                enabled: false
            }
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            curve: 'straight'
        },
        subtitle: {
            text: 'Price Movements',
            align: 'left'
        },
        labels: series.monthDataSeries1.dates,
        xaxis: {
            type: 'month',
        },
        yaxis: {
            opposite: true
        },
        legend: {
            horizontalAlign: 'left'
        }
    }).render();

}