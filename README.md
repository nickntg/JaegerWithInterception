# Jaeger with interception

This is a sample solution that incorporates an API and a web front-end that calls it, both of which are using [Jaeger](https://www.jaegertracing.io/). Both projects are using the [OpenTracing](https://opentracing.io/) .Net core libraries. Additionally, the API is using [Foil](https://github.com/moattarwork/foil) to intercept calls to injected services and add a new span.
