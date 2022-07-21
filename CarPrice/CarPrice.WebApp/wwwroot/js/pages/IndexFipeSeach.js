
$(document).ready(function () {
    $('#modelYear').datepicker({
        clearBtn: true,
        format: "yyyy",
        startView: "years",
        minViewMode: "years"
    });

    $("#fipeCodeSearch").mask("999999-9");
});

function consultaPrecosFipe() {
    var base_url = window.location.origin;

    $("#alertSearch").attr("hidden", true);

    var fipeCode = $("#fipeCodeSearch").val();
    var modelYear = $("#modelYear").val();
    var url = base_url + `/Search/SearchByFipeCode?fipeCode=${fipeCode}&year=${modelYear}`

    $.get(url, function (data) {

        if (type = "sucess") {
            fillInPriceChart(data.data);
            preencherCards(data.data);
        } else {
            $("#alertSearchMessage").text(data.message);
            $("#alertSearch").attr("hidden", false);
        }        
    }); 
}

function preencherCards(data) {
    $("#valorMesAtual").html(data.currentPrice)
    $("#valorPrecoMedio").html(data.averagePrice)
}

function fillInPriceChart(data) {

    var prices = [];
    var dates = [];

    data.priceVariationChart.forEach(function (item) {
        prices.push(item.price);
        dates.push(item.monthYear);
    });

    const series = {
        "monthDataSeries1": {
            "prices": prices,
            "dates": dates
        }
    }

    new ApexCharts(document.querySelector("#areaChart"), {
        series: [{
            name: "Preço",
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
            text: 'Movimentação do Preço',
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