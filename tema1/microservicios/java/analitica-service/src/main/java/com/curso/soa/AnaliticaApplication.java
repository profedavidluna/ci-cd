package com.curso.soa;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;

@SpringBootApplication
@EnableDiscoveryClient
public class AnaliticaApplication {

	public static void main(String[] args) {
		SpringApplication.run(AnaliticaApplication.class, args);
	}

}
