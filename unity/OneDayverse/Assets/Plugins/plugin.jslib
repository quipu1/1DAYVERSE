mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
  },

  GetUsername: function () {
    console.log(window.localStorage.getItem("username"));
    return currentUsername;
  }
});