window.APIWorkWithClass = (function () {
    return {
        addClass: function (elem, nameOfClass) {
            var classes = elem.className;
            if (classes.indexOf(nameOfClass) == -1) {
                elem.className = elem.className + " " + nameOfClass;
            }
        },
        
        removeClass: function (elem, nameOfClass) {
            var classes = elem.className;
            positionOfClass = classes.indexOf(nameOfClass);
            if (positionOfClass != -1) {
                elem.className = elem.className.slice(0, positionOfClass) +
                                 elem.className.slice(positionOfClass + nameOfClass.length + 1);
            }
        },

        toggle: function (elem, nameOfClass) {
            var classes = elem.className;
            if (classes.indexOf(nameOfClass) == -1) {
                this.addClass(elem, nameOfClass);
            }
            else {
                this.removeClass(elem, nameOfClass);
            }
        },

        closest: function (elem, selector) {
            var searchElem;
            if (this.isSelector(elem,selector)) {
                return elem;
            }
            else {
                searchElem = elem;
                while (searchElem.parentElement) {
                    searchElem = searchElem.parentElement;
                    if (this.isSelector(searchElem,selector)) {
                        return searchElem;
                    }
                }
                return null;
            }
        },

        isSelector: function (elem, selector) {
            var i = 0,
                elems = document.querySelectorAll(selector);
            while (elems.item(i)) {
                if (elems.item(i) == elem) {
                    return true;
                }
                i++;
            }
            return false;
        }
    }
}())