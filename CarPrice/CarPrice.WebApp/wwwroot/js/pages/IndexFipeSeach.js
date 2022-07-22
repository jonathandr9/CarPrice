
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

    if (data.photo == "") {
        $("#addPhoto").attr("hidden", false);
    } else {
        $("#carPhoto").attr("src", data.photo);
    }
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

function buscarImagem(input) {
    if (input.files && input.files[0]) {
        let reader = new FileReader();
        reader.onload = (e) => {
            let imgData = e.target.result;

            $("#carPhoto").attr("src", imgData);
            $("#addPhoto").attr("hidden", true);

            var fipeCode = $("#fipeCodeSearch").val();
            var modelYear = $("#modelYear").val();

            let photo = {
                fipeCode: fipeCode,
                modelYear: parseInt(modelYear),
                photoBase64: imgData
            }

            let base_url = window.location.origin;
            let url = base_url + `/Search/AddPhoto`

            //$.post(url, data, function (result) {
            //    alert(result.message);
            //}, "json")

            $.ajax({
                url: url,
                type: "POST",
                data: JSON.stringify(photo),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    alert(result.message);
                }
            })
        }
        reader.readAsDataURL(input.files[0]);
    }
}