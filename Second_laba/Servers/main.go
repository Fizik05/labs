package main

import (
	"encoding/json"
	"net/http"
	"sync"
)

type Response struct {
	Message string `json:"message"`
}

func main() {
	var wg sync.WaitGroup

	wg.Add(1)

	go func() {
		http.HandleFunc("/first_server", func(w http.ResponseWriter, r *http.Request) {
			response := Response{Message: "Response from first server"}
			json.NewEncoder(w).Encode(response)
		})

		http.ListenAndServe(":8080", nil)
	}()

	go func() {
		http.HandleFunc("/second_server", func(w http.ResponseWriter, r *http.Request) {
			response := Response{Message: "Response from second server"}
			json.NewEncoder(w).Encode(response)
		})

		http.ListenAndServe(":8081", nil)
	}()

	go func() {
		http.HandleFunc("/third_server", func(w http.ResponseWriter, r *http.Request) {
			response := Response{Message: "Response from third server"}
			json.NewEncoder(w).Encode(response)
		})

		http.ListenAndServe(":8082", nil)
	}()

	wg.Wait()
}
