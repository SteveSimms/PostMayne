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
    const getRequest = () => {

        log(formValues.value)

        axios.get(formValues.value)
            .then((response) => {
                log(response.headers)
                formValues.value = `Data: ${response.data} Status: ${response.statusText} ${response.status} Headers: ${response.headers}`
            })
        formValues.value = ''
    }
    console.log(formValues.value.getReq)

    const postRequest = () => {
        axios.post('http://localhost:5164/post')
            .then((response) => {
                formValues.value = `Data: ${response.data} Status: ${response.statusText} ${response.status} Headers: ${response.headers}`
            })
    }

</script>

<template>
    <h1>{{ msg }}</h1>
    <h1>{{ test }} </h1>
    <form @submit.prevent="getRequest" action="/" method="post">
        <label>GetRequest</label>
        <input v-model="formValues" name="name" />
    </form>
    <form @submit.prevent="postRequest" action="/" method="post">
        <label>PostRequest</label>
        <input v-model="formValues" name="name" />
    </form>
    <h1>{{formValues }}</h1>
</template>

<style scoped>
    a {
        color: #42b983;
    }
</style>
