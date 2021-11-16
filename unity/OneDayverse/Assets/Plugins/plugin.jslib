mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
  },

  GetUsername: function () {
    var returnStr = window.localStorage.getItem("username");
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer;
  },

  setLectureCate: function(v) {
    let name = v;
    window.localStorage.setItem("inLectureName", name);
  },

  setLectureId: function(v) {
    let id = v;
    window.localStorage.setItem("inLectureId", id);
  },

});


