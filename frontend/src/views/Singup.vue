<template>
  <div>
    <h1>Sign Up</h1>
    <form action="#" class="container">
      <div>
        <p class="radio-text">Select Your Job</p>
        <div class="radio">
          <div class="radio-input">
            <input type="radio" id="student" v-model="job" name="job" value="student" checked>
            <label for="student">student</label>
          </div>
          <div class="radio-input">
            <input type="radio" id="professor" v-model="job" name="job" value="professor">
            <label for="professor">professor</label>
          </div>
        </div>
      </div>
      <div class="form-element">
        <input type="text" name="userid" v-model="userId" id="userid" required/>
        <label class="floating-label" for="username">Enter Your User ID
        </label>
        <div v-if="userId === ''" class="alert">
          <svg xmlns="http://www.w3.org/2000/svg" width="1rem" height="1rem" fill="currentColor" class="bi bi-exclamation-triangle" style="margin-right: 0.2rem">
            <path d="M7.938 2.016A.13.13 0 0 1 8.002 2a.13.13 0 0 1 .063.016.146.146 0 0 1 .054.057l6.857 11.667c.036.06.035.124.002.183a.163.163 0 0 1-.054.06.116.116 0 0 1-.066.017H1.146a.115.115 0 0 1-.066-.017.163.163 0 0 1-.054-.06.176.176 0 0 1 .002-.183L7.884 2.073a.147.147 0 0 1 .054-.057zm1.044-.45a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566z"/>
            <path d="M7.002 12a1 1 0 1 1 2 0 1 1 0 0 1-2 0zM7.1 5.995a.905.905 0 1 1 1.8 0l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995z"/>
          </svg>
          <span>
            아이디를 입력해주세요.
          </span>
        </div>
      </div>
      <div class="form-element">
        <input type="text" name="email" v-model="email" id="email" required />
        <label class="floating-label" for="email">Enter Your Email</label>
        <div v-if="email === '' || email_error" class="alert">
          <svg xmlns="http://www.w3.org/2000/svg" width="1rem" height="1rem" fill="currentColor" class="bi bi-exclamation-triangle" style="margin-right: 0.2rem">
            <path d="M7.938 2.016A.13.13 0 0 1 8.002 2a.13.13 0 0 1 .063.016.146.146 0 0 1 .054.057l6.857 11.667c.036.06.035.124.002.183a.163.163 0 0 1-.054.06.116.116 0 0 1-.066.017H1.146a.115.115 0 0 1-.066-.017.163.163 0 0 1-.054-.06.176.176 0 0 1 .002-.183L7.884 2.073a.147.147 0 0 1 .054-.057zm1.044-.45a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566z"/>
            <path d="M7.002 12a1 1 0 1 1 2 0 1 1 0 0 1-2 0zM7.1 5.995a.905.905 0 1 1 1.8 0l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995z"/>
          </svg>
          <span>
            이메일을 확인해주세요.
          </span>
        </div>
      </div>
      <div class="form-element">
        <input type="password" name="password" v-model="password" id="password" required />
        <label class="floating-label" for="password">Enter Your user Password</label>
      </div>
      <div class="form-element">
        <input type="password" name="password_confirm" v-model="password_confirm" id="password_confirm" required />
        <label class="floating-label" for="password_confirm">Confirm Your User Password</label>
        <div v-if="password === '' || password != password_confirm" class="alert">
          <svg xmlns="http://www.w3.org/2000/svg" width="1rem" height="1rem" fill="currentColor" class="bi bi-exclamation-triangle" style="margin-right: 0.2rem">
            <path d="M7.938 2.016A.13.13 0 0 1 8.002 2a.13.13 0 0 1 .063.016.146.146 0 0 1 .054.057l6.857 11.667c.036.06.035.124.002.183a.163.163 0 0 1-.054.06.116.116 0 0 1-.066.017H1.146a.115.115 0 0 1-.066-.017.163.163 0 0 1-.054-.06.176.176 0 0 1 .002-.183L7.884 2.073a.147.147 0 0 1 .054-.057zm1.044-.45a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566z"/>
            <path d="M7.002 12a1 1 0 1 1 2 0 1 1 0 0 1-2 0zM7.1 5.995a.905.905 0 1 1 1.8 0l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995z"/>
          </svg>
          <span>
            비밀번호를 확인해주세요.
          </span>
        </div>
      </div>
      <button class="btn active" v-if="userId && email && !email_error && password_confirm && password === password_confirm">Sign Up</button>
      <button class="btn nonactive" v-else>Sign Up</button>
    </form>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        job: 'student',
        userId: '',
        email: '',
        password: '',
        password_confirm: '',
      }
    },
    computed: {
      email_error() {
        if (this.email != '') {
          var lst = this.email.split("@")
          if (lst.length != 2) {
            return true
          }
          var pattern = lst[1].split(".")
          if (pattern.length != 2) {
            return true
          }
          return false
          }
        return true
      }
    },
    methods: {
    }
  }
</script>

<style scoped>
body {
  font-size: 16px;
}
.container {
  display: block;
  width: 450px;
  margin: 50px auto;
  border-radius: 4px;
}
.container .form-element {
  position: relative;
  padding-bottom: 16px;
}
.form-element input {
  box-sizing: border-box;
  width: 100%;
  padding: 16px 20px 0 20px;
  height: 50px;
  font-size: 16px;
  border: none;
  border-radius: 5px;
  background-color: #F6F6F6;
  color: #000000;
}
.floating-label {
  box-sizing: border-box;
  position: absolute;
  top: 25%;
  left: 20px;
  font-size: 14px;
  cursor: text;
  color: #8c8c8c;
  transition: font 0.1s ease, top 0.1s ease, transform 0.1s ease;
  transition: font 0.1s ease, top 0.1s ease, transform 0.1s ease,
    -webkit-transform 0.1s ease, -moz-transform 0.1s ease,
    -o-transform 0.1s ease;
}
.btn {
  width: 100%;
  height: 50px;
  margin-top: 24px;
  font-size: 18px;
  font-weight: 700;
  border-radius: 30px;
  border: none;
  color: #ffffff;
  background-color: #F4C7F5;
}
.active {
  cursor: pointer;
  background-color: #F4C7F5;
}
.nonactive {
  background-color: gray;
}
input:focus ~ .floating-label,
input:valid ~ .floating-label {
  font-size: 11px;
  top: 7px;
}
input:-webkit-autofill,
input:-webkit-autofill:focus {
  transition: background-color 600000s 0s, color 600000s 0s;
}
.alert {
  position: absolute;
  top: 20%;
  right: 0%;
  color: rgba(255, 97, 97, 0.822);
  text-align: start;
  font-size: 0.8rem;
  padding: 0 1rem;
  vertical-align: top;
  display: flex;
  align-content: center;
  margin-top: 0.3rem;
}
.radio {
  display: flex;
  justify-content: center;
  margin: 1rem 1rem;
}
.radio-text {
  font-weight: bold;
  font-size: 1.5rem;
}
.radio-input {
  margin: 0 1rem;
}
</style>