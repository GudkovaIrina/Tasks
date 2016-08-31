/// <reference path="Scripts/jquery-3.1.0.js" />
window.APIScrollingPages = (function () {
    'use strict';

    return {
        startScrollingPages: startScrollingPages
    };
    var time,
        timeOutScrolling,
        timeOutTimer,
        numberCurrentPage,
        $container,
        $timer,
        $progressBar,
        $buttonControlTimer,
        $buttonToPreviousPage,
        $modalWindow,
        $buttonYes,
        $buttonNo;

    function startScrollingPages (listPages, timeIntervalSeconds) {
        
        numberCurrentPage = 0;
        time = timeIntervalSeconds;

        $container = createElementForScrollingPages('<div class="container"></div>', document.body);

        $timer = createElementForScrollingPages('<div class="timer lead"></div>', $container);

        $progressBar = createElementForScrollingPages('<div class="progress">\n<div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 0%;">\n <span class="sr-only"> 0% Complete</span> \n </div> \n </div>', $container);
        $progressBar = $progressBar.children();

        $buttonControlTimer = createElementForScrollingPages(
            '<input type="button" class="control-timer btn btn-danger" value="Stop timer!"/> ', $container);
        $buttonControlTimer.on("click", function () {
            controlTimer(listPages, timeIntervalSeconds);
        });
        
        $buttonToPreviousPage = createElementForScrollingPages(
            '<input type="button" class="previous-page hide btn btn-primary" value="Previous page"/> ', $container);
        $buttonToPreviousPage.on("click", function () {
            toPreviousPage(listPages, timeIntervalSeconds)
        });
        
        timeOutTimer = setInterval(function () { showTime(timeIntervalSeconds); }, 1000);
        timeOutScrolling = setTimeout(function () {
            transitionToNextPage(listPages, timeIntervalSeconds)
        }, time * 1000 + 1000);

        $modalWindow = createElementForScrollingPages('<div class="modal-window"></div>', document.body);
        $modalWindow.load("/ModalWindow.html", function () {
            $buttonYes = $('#btnYes');
            $buttonYes.on("click", function () {
                timeOutTimer = setInterval(function () { showTime(timeIntervalSeconds); }, 1000);
                numberCurrentPage = 0;
                toPageWithNumber(listPages, timeIntervalSeconds, numberCurrentPage);
            });
            $buttonNo = $("#btnNo");
            $buttonNo.on("click", function () {
                window.close();
            });
        });
    }

    function createElementForScrollingPages(content,toElement) {
        var $element = $(content);
        $element.appendTo(toElement);
        return $element;
    }

    function transitionToNextPage(listPages, timeIntervalSeconds) {
        if (numberCurrentPage == listPages.length - 1) {
            clearInterval(timeOutTimer);
            $('#modal-message').modal('show');
        }
        else {
            numberCurrentPage++;
            toPageWithNumber(listPages, timeIntervalSeconds, numberCurrentPage);
        }
    }

    function showTime(timeIntervalSeconds) {
        var progressValue = time / timeIntervalSeconds*100;
        $timer.text("It has " + time + " seconds!");
        $progressBar.attr({ "aria-valuenow": progressValue + "", "style": "width: " + progressValue + "%" });
        time--;
    }

    function controlTimer(listPages, timeIntervalSeconds) {
        if ($buttonControlTimer[0].value == "Stop timer!") {
            clearTimeout(timeOutScrolling);
            clearInterval(timeOutTimer);
            $buttonControlTimer[0].value = "Run timer!";
            if (!$buttonToPreviousPage.hasClass("hide")) {
                $buttonToPreviousPage.addClass("hide");
            }
        }
        else {
            $buttonControlTimer[0].value = "Stop timer!";
            timeOutTimer = setInterval(function () { showTime(timeIntervalSeconds); }, 1000);
            timeOutScrolling = setTimeout(function () {
                transitionToNextPage(listPages, timeIntervalSeconds);
            }, time * 1000 + 1000);
            if (numberCurrentPage != 0) {
                $buttonToPreviousPage.removeClass("hide");
            }
        }
    }
    
    function toPreviousPage(listPages, timeIntervalSeconds) {
        numberCurrentPage-- ;
        clearTimeout(timeOutScrolling);
        toPageWithNumber(listPages, timeIntervalSeconds, numberCurrentPage);
    }

    function toPageWithNumber(listPages, timeIntervalSeconds, numberPage) {
        time = timeIntervalSeconds;
        timeOutScrolling = setTimeout(function () {
            transitionToNextPage(listPages, timeIntervalSeconds);
        }, time * 1000 + 1000);
        $("#content").load(listPages[numberPage] + " #content");
        if (numberPage == 1) {
            $buttonToPreviousPage.removeClass("hide");
        } else if (!numberPage) {
            if (!$buttonToPreviousPage.hasClass("hide")) {
                $buttonToPreviousPage.addClass("hide");
            }
        }
    }
}())