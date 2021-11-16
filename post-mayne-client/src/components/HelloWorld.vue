<script setup>
    import { ref } from 'vue'
    import axios from 'axios'
    let test = ref('Yo!!!')
    const log = console.log

    defineProps({
        msg: String
    })

    const count = ref(0)

    let formValues = ref(''
       

    )

    let getTest = async () => {
        await axios.get('http://localhost:5164/test')
            .then((response) => {
                test.value = response.data
                log(test.value)
                return test.value
            })
    }
    getTest()

    //TODO: creat a from that takes input (http endpoint) and returns the service code and the response body
    const sendRequest = () => {
        
        log(formValues.value)
       
        axios.get(formValues.value)
            .then((response) => {
                formValues.value = response.data
            })
        formValues.value = ''
    }
    console.log(formValues.value.getReq)
</script>

<template>
    <h1>{{ msg }}</h1>
    <h1>{{ test }} </h1>
    <form @submit.prevent="sendRequest" action="/" method="post">
        <label>GetRequest</label>
        <input v-model="formValues" name="name" />
    </form>
    <h1>Response Data: {{formValues }}</h1>
</template>

<style scoped>
    a {
        color: #42b983;
    }
</style>
