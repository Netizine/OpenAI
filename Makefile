.PHONY: update-version codegen-format
update-version:
	@echo "$(VERSION)" > VERSION
	@perl -pi -e 's|<Version>[.\-\d\w]+</Version>|<Version>$(VERSION)</Version>|' src/Stripe.net/Stripe.net.csproj

codegen-format:
	dotnet format src/Stripe.net/Stripe.net.csproj
