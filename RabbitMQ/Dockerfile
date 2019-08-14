FROM rabbitmq:3.7.7-management
COPY configs/definitions.json /etc/rabbitmq/
RUN printf 'management.load_definitions = /etc/rabbitmq/definitions.json\n' >> /etc/rabbitmq/rabbitmq.conf

# Ref https://qiita.com/yurak/items/53db262d214786da6837