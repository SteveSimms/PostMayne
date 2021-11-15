<script setup>
    import { ref } from 'vue'
    import axios from 'axios'
    let test = ref('Yo!!!')

    defineProps({
        msg: String
    })

    const count = ref(0)

    let getTest = async () => {
        await axios.get('http://localhost:5164/test')
            .then((response) => {
                test.value = response.data
                console.log(test.value)
                return test.value
            })
    }
    getTest()

</script>

<template>
    <h1>{{ msg }}</h1>
    <h1>{{    test }} </h1>
</template>

<style scoped>
    a {
        color: #42b983;
    }
</style>
