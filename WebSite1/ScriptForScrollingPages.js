window.APIScrollingPages = (function () {
    return {
        startScrollingPages: startScrollingPages
    };

    function startScrollingPages(listPages, timeIntervalSeconds) {
        var time = timeIntervalSeconds,
            numberCurrentPage = listPages.indexOf(location.pathname),
            timer,
            timeOutScrolling,
            timeOutTimer,
            buttonControlTimer,
            buttonToPreviousPage;

        timer = createElementForScrollingPages({
            tagName: "div",
            className: "timer"
        });

        buttonControlTimer = createElementForScrollingPages({
            tagName: "input",
            type: "button",
            className: "control-timer",
            value: "Stop timer!"
        });
        buttonControlTimer.addEventListener("click", function () {
            controlTimer(buttonControlTimer, timeOutScrolling, timeOutTimer, timer, time, listPages, numberCurrentPage);
        });

        if (location.pathname != listPages[0]) {
            buttonToPreviousPage = createElementForScrollingPages({
                tagName: "input",
                type: "button",
                className: "previous-page",
                value: "Previous page"
            });
            buttonToPreviousPage.addEventListener("click", function () {
                toPreviousPage(listPages, numberCurrentPage)
            });
        }

        timeOutTimer = setInterval(function () { time = showTime(timer, time); }, 1000);
        timeOutScrolling = setTimeout(function () {
            transitionToNextPage(listPages, numberCurrentPage)
        }, time * 1000 + 1000);
    }

    function createElementForScrollingPages(attributsOfElement) {
        var element = document.createElement(attributsOfElement.tagName);
        element.setAttribute("type", attributsOfElement.type);
        element.setAttribute("class", attributsOfElement.className);
        element.setAttribute("value", attributsOfElement.value);
        document.body.appendChild(element);
        return element;
    }

    function transitionToNextPage(listPages, numberCurrentPage) {
        if (numberCurrentPage == listPages.length - 1) {
            if (confirm("Do you want to look photo at first?")) {
                location.replace(listPages[0]);
            }
            else {
                window.close();
            }
        }
        else {
            numberCurrentPage++;
            location.replace(listPages[numberCurrentPage]);
        }
    }

    function showTime(timer, time) {
        var content = document.createTextNode("It has " + time + " seconds!");
        while (timer.firstChild) {
            timer.removeChild(timer.firstChild)
        }
        timer.appendChild(content);
        return time - 1;
    }

    function controlTimer(buttonControlTimer, timeOutScrolling, timeOutTimer, timer, time, listPages, numberCurrentPage) {
        if (buttonControlTimer.value == "Stop timer!") {
            clearTimeout(timeOutScrolling);
            clearInterval(timeOutTimer);
            buttonControlTimer.value = "Run timer!";
        }
        else {
            buttonControlTimer.value = "Stop timer!";
            timeOutTimer = setInterval(function () { time = showTime(timer, time); }, 1000);
            timeOutScrolling = setTimeout(function () {
                transitionToNextPage(listPages, numberCurrentPage)
            }, time * 1000);
        }
    }

    function toPreviousPage(listPages, numberCurrentPage) {
        numberCurrentPage--;
        location.replace(listPages[numberCurrentPage]);
    }
}());