#!/bin/bash

# Define the list of services
services=("ProductService" "OrderService" "CustomerService")

# Loop through each service
for service in "${services[@]}"; do
    if [[ -n "$service" ]]; then
        mkdir -p "$service"
    fi
    
    # Create subdirectories
    mkdir -p "$service/Controllers"
    mkdir -p "$service/Models"
    mkdir -p "$service/Services"
    mkdir -p "$service/Repositories"
    mkdir -p "$service/Data"

    # Print message
    echo "Dossiers créés pour $service"
done

