window.APISelectOptions = (function () {
    return {
        init: init
    };

    var i;

    function init(selectOptions) {
        var lastSelected,
            leftList = selectOptions.querySelector(".left"),
            rightList = selectOptions.querySelector(".right"),
            buttonAllToRight = selectOptions.querySelector(".all-to-right"),
            buttonAllToLeft = selectOptions.querySelector(".all-to-left"),
            buttonSelectedToRight = selectOptions.querySelector(".selected-to-right"),
            buttonSelectedToLeft = selectOptions.querySelector(".selected-to-left");

        selectOptions.addEventListener("click", function (e) {
            lastSelected = selected(e, lastSelected);
        });

        buttonSelectedToRight.addEventListener("click", function () { moveSelectedElement(leftList, rightList); });
        buttonSelectedToLeft.addEventListener("click", function () { moveSelectedElement(rightList, leftList); });
        buttonAllToRight.addEventListener("click", function () { moveAllElement(leftList, rightList) });
        buttonAllToLeft.addEventListener("click", function () { moveAllElement(rightList, leftList) });
    }

    function selected(e, lastSelected) {
        var target = APIWorkWithClass.closest(e.target, ".option");
        if (!target) return;
        if (e.shiftKey) {
            return selectedIntervalOptions(target, lastSelected);
        }
        else if (e.ctrlKey) {
            return addOrRemoveSelection(target, lastSelected);
        }
        else {
            return selectedSingleOptions(target, e, lastSelected);
        }
    }

    function selectedSingleOptions(option, e, lastSelected) {
        removeOldSelect(e.currentTarget);
        APIWorkWithClass.addClass(option, "selected");
        return option;
    }

    function selectedIntervalOptions(toOption, lastSelected) {
        var isLastSelectedBeforeCurrent, elem;
        if (!toOption.parentElement.contains(lastSelected) && lastSelected) {
            removeOldSelect(lastSelected.parentElement);
            lastSelected = toOption.parentElement.children[0];
        }

        isLastSelectedBeforeCurrent = lastSelected.compareDocumentPosition(toOption) & 4;
        if (isLastSelectedBeforeCurrent) {
            for (elem = lastSelected; elem != toOption; elem = elem.nextElementSibling) {
                APIWorkWithClass.addClass(elem, "selected");
            }
        }
        else {
            for (elem = lastSelected; elem != toOption; elem = elem.previousElementSibling) {
                APIWorkWithClass.addClass(elem, "selected");
            }
        }
        toOption.className = "option selected";
        return toOption;
    }

    function addOrRemoveSelection(option, lastSelected) {
        if (!option.parentElement.contains(lastSelected)  && lastSelected) {
            removeOldSelect(lastSelected.parentElement);
        }
        APIWorkWithClass.toggle(option, "selected");
        return option;
    }

    function removeOldSelect(list) {
        var listOfSelected = list.getElementsByClassName("selected");

        while (listOfSelected.length) {
            APIWorkWithClass.removeClass(listOfSelected[0], "selected");
        }
    }

    function moveSelectedElement(source, destination) {
        var selectedElements = source.querySelectorAll(".selected");
        if (selectedElements.length == 0) {
            alert("There are not selected element!");
        }
        else {
            for (i = 0; i < selectedElements.length; i++) {
                destination.appendChild(selectedElements[i]);
                APIWorkWithClass.removeClass(selectedElements[i], "selected");
            }
        }
    }

    function moveAllElement(source, destination) {
        while (source.firstChild) {
            destination.appendChild(source.firstChild);
        }
    }
}());
